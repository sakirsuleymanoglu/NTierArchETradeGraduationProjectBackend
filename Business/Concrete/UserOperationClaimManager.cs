using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _userService = userService;
        }

        public IResult AddDefaultClaim(int userId)
        {
            var result = BusinessRules.Run(CheckIfExistsOfUser(userId));

            if (result != null)
            {
                return result;
            }

            _userOperationClaimDal.Add(new UserOperationClaim
            {
                UserId = userId,
                OperationClaimId = 3
            });

            return new SuccessResult(Messages.UserOperationClaimInsertionSuccess);
        }

        private IResult CheckIfExistsOfUser(int userId)
        {
            var result = _userService.GetById(userId);

            if (result == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            return new SuccessResult();
        }
    }
}
