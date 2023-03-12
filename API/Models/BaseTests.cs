using System;


namespace API.Services
{
    public class BaseTests :  IDisposable
    {
        public VirtualStoreUserService virtualStoreUser;
        public VirtualStoreProductService virtualStoreProduct;

        public BaseTests()
        {
            virtualStoreUser = new VirtualStoreUserService();
            virtualStoreProduct = new VirtualStoreProductService();

        }

        public void Dispose() { }

    }
 
}
