using TechTalk.SpecFlow;

namespace API.Services
{
      [Binding]
    public sealed class VirtualStoreStep : BaseTests
    {
        public string idUser;
        public string idProduct;
        public string tokenBearer;
        public string user;
        public string passwd;


       
        [Given(@"I use user API to register a new user")]
        public void GivenIUseUserAPIToRegisterANewUser(Table tableUser)
        {
            idUser = virtualStoreUser.CreateUser(tableUser);
            FeatureContext.Current["PersistentIdUser"] = idUser;

            foreach (TableRow row in tableUser.Rows)
            {
                user =  row["email"].ToString();
                passwd = row["password"].ToString();
            }
 
        }

        [Then(@"generate a token")]
        public void ThenGenerateAToken()
        {
            tokenBearer = virtualStoreUser.GerToken(user, passwd);
            FeatureContext.Current["PersistentToken"] = tokenBearer;
        }

        
        public void GenerateTokenBeforeProductRegistration()
        {
            ThenGenerateAToken();
        }

        [Then(@"I check created user")]
        public void ThenICheckCreatedUser()
        {
            virtualStoreUser.CheckNewUser(idUser);
        }


        
        [Given(@"I use product API to register a new product")]
        public void GivenIUseProductAPIToRegisterANewProduct(Table tableProduct)
        {
            string value = FeatureContext.Current["PersistentToken"] as string;
            idProduct = virtualStoreProduct.CreateProduct(tableProduct, value);
        }

        [Then(@"I check created product")]
        public void ThenICheckCreatedProduct()
        {
            virtualStoreProduct.CheckNewProduct(idProduct);
        }


        [Then(@"I delete this product")]
        public void ThenIDeleteThisProduct()
        {
            string value = FeatureContext.Current["PersistentToken"] as string;
            virtualStoreProduct.DeleteProduct(idProduct, value);
        }

        [Then(@"I delete this user")]
        public void ThenIDeleteThisUser()
        {
            string valueIdUser = FeatureContext.Current["PersistentIdUser"] as string;
            virtualStoreUser.DeleteUser(valueIdUser);
        }

    }
}
