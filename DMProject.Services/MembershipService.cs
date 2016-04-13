using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMProject.Services.Abstract;
using DMProject.Services.Utilities;
using DMProject.Entities;
using DMProject.Data.Repositories;
using DMProject.Data.Infrastructure;
using DMProject.Data.Extensions;
using System.Security.Principal;
namespace DMProject.Services
{
    public   class MembershipService :IMembershipService
    {

        #region Variables
        private readonly IEntityBaseRepository<UserEntity> _userRepository;
        private readonly IEntityBaseRepository<RoleDefine> _roledefRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEntityBaseRepository<RolePrivilege> _roleprivilegeRepository;  
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        public MembershipService(IEntityBaseRepository<UserEntity> userRepository, IEntityBaseRepository<RoleDefine> roleRepository,
 IEntityBaseRepository<UserRole> userRoleRepository, IEntityBaseRepository<RolePrivilege> roleprivilegeRepository,  IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roledefRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
            _roleprivilegeRepository = roleprivilegeRepository;
        }
        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.name);
                membershipCtx.UserEntity = user;

                var identity = new GenericIdentity(user.name);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.code).ToArray());
            }

            return membershipCtx;

        }

       public UserEntity CreateUser(UserEntity userentity, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUsername(userentity.name);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new UserEntity()
            {
                name = userentity.name,
                salt = passwordSalt,
                email = userentity.email,
                islocked = false,
                password = _encryptionService.EncryptPassword(userentity.password, passwordSalt),
                createdate = DateTime.Now,
                birthday = DateTime.Now,
                mobile = userentity.mobile,
                truename = userentity.truename,
                sex = userentity.sex
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            /*
            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    addUserToRole(user, role);
                }
            }*/

           // _unitOfWork.Commit();

            return user;
        }
        private void addUserToRole(UserEntity user, int roleId)
        {
            var role = _roledefRepository.GetSingle(roleId);
            if (role == null)
                throw new ApplicationException("Role doesn't exist.");

            var userRole = new UserRole()
            {
                RoleDefineId = role.id,
                UserEntityId = user.id
            };
            _userRoleRepository.Add(userRole);
        }
       public UserEntity GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }
       public List<Privilege> GetUserRoles(string username) {
            List<Privilege> _result = new List<Privilege>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                var userrole = _userRoleRepository.GetUserRoleList(existingUser.id).ToList() ;
              //  UserRole myrecv = new userrole.ToList();


                foreach (var userRole in userrole)
                {
                    var rolepri = _roleprivilegeRepository.GetRolePrivilegeList(userRole.RoleDefineId).ToList();
                    foreach (var privilege in rolepri)
                    {
                        _result.Add(privilege.Privilege);
                    }
                }
            }
            return _result.Distinct().ToList();
        }
        private bool isPasswordValid(UserEntity user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.salt), user.password);
        }

        private bool isUserValid(UserEntity user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.islocked;
            }

            return false;
        }
    }
}
