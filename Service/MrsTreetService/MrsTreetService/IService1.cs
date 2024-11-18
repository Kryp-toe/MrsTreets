using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MrsTreetService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        // PRODUCT Methods
        [OperationContract]
        PRODUCT addProduct(int businessID, string name, string description, string category, string allergies, decimal price);

        [OperationContract]
        bool editProduct(int id, string name, decimal price, string description, string allergies, string category, bool active);

        [OperationContract]
        bool removeProduct(int Id);

        [OperationContract]
        bool deleteProduct(int ID);

        [OperationContract]
        List<PRODUCT> getAllProducts(int businessID);

        [OperationContract]
        List<PRODUCT> getAllActiveProducts(int businessID);

        [OperationContract]
        List<PRODUCT> getAllActiveProductsFiltered(int businessID, string filter);

        [OperationContract]
        PRODUCT getProduct(int productId);

        [OperationContract]
        decimal getProductPrice(int productId);

        [OperationContract]
        string getProductName(int productId);

        // BUSINESS Methods
        [OperationContract]
        BUSINESS addRest(int ownerID, string name, string address, string image, string description);

        [OperationContract]
        bool editBusiness(int id, string name, string address, string image, string description, bool status);

        [OperationContract]
        bool deleteRest(int id);

        [OperationContract]
        string getBusName(int businessID);

        [OperationContract]
        List<BUSINESS> getAllRests();

        [OperationContract]
        List<BUSINESS> getAllRestByOwner(int ownerID);

        [OperationContract]
        BUSINESS getRest(int id);

        [OperationContract]
        string getBusAddress(int budID);

        // CART Methods
        [OperationContract]
        CART getCart(int cartId);

        [OperationContract]
        CART createCart(int userId, int prodId);

        [OperationContract]
        CART getCartByUser(int userId);

        [OperationContract]
        CART getCartAtBus(int userId, int busId);

        [OperationContract]
        List<BRIDGE> getProdsInCart(int cartId);

        [OperationContract]
        bool addToCart(int userId, int productId, int cartId, int quantity);

        [OperationContract]
        int getProdQuantity(int productId, int cartId);

        [OperationContract]
        void calcCartTotal(int cartId);

        //DISCOUNT Methods
        [OperationContract]
        bool setDiscountCode(string code, int prodId, decimal newPrice);

        [OperationContract]
        List<DISCOUNT> getBusDiscounts(int busId);

        [OperationContract]
        bool editDiscount(int disId, string code, decimal price, bool active);

        [OperationContract]
        int getCodeProdID(string code, int busId);

        [OperationContract]
        bool addDiscountToCart(int cartId, int prodId, string code);

        // CHECKOUT Methods
        [OperationContract]
        INVOICE checkout(int cartId, string paymentmethod);

        [OperationContract]
        INVOICE getInvoice(int invoiceId);

        [OperationContract]
        List<ORDERITEM> getItems(int invoice);

        [OperationContract]
        List<INVOICE> getUserInvoices(int userID);

        [OperationContract]
        List<INVOICE> getBusInvoices(int busID);

        // USER Methods
        [OperationContract]
        USER registerUser(string name, string secondaryName, string email, string password, string phoneNumber, string dob, string gender, string typeOf);

        [OperationContract]
        bool editUser(int id, string name, string secondaryName, string email, string phoneNumber, string dob, string gender);

        [OperationContract]
        bool emailExists(string email);

        [OperationContract]
        USER getUserByEmail(string email);

        [OperationContract]
        USER getUserByID(int id);

        [OperationContract]
        USER login(string email, string password);

        [OperationContract]
        string logOut(string email, string password);

        [OperationContract]
        void removeAsAdmin(int id);

        [OperationContract]
        bool passwordChanged(string password, string email);




        [OperationContract]
        List<PRODUCT> getSearchedProducts(string search, int businessID);

        [OperationContract]
        List<BUSINESS> getSearchedBusinessLocation(string search);


        //edits customer information
        [OperationContract]
        bool editCustomer(int id, string name, string surname, string email, string phoneNumer);
    }
}
