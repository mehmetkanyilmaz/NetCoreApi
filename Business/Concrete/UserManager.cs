using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            var result = _userDal.Add(user);
            if (result == null)
                return new ErrorResult(Messages.UserAddError);

            return new SuccessResult(Messages.UserAddSuccess);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(x => x.Email == email);
            if (result == null)
                return new ErrorDataResult<User>(Messages.UserSearchError);

            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            if (result == null)
                return new ErrorDataResult<List<OperationClaim>>(Messages.UserClaimListError);

            return new SuccessDataResult<List<OperationClaim>>(result);
        }
    }
}
