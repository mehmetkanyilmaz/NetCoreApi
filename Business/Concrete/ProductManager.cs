using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IDataResult<Product> Add(Product product)
        {
            var result = _productDal.Add(product);
            if (result == null)
                return new ErrorDataResult<Product>(Messages.ProductAddError);

            return new SuccessDataResult<Product>(result);
        }

        public IResult Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            var result = _productDal.GetList();

            if (result == null)
                return new ErrorDataResult<List<Product>>(Messages.ProductListError);

            return new SuccessDataResult<List<Product>>(result.ToList());
        }

        public IDataResult<List<Product>> GetListByCategoriy(int categoriyId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
