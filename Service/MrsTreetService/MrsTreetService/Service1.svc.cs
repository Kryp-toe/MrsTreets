using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MrsTreetService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 :IService1
    {
        MrsTreetsDataClassDataContext dataContext = new MrsTreetsDataClassDataContext();

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
        */
        //PRODUCT Methods
        //Add a prodcut to catalogue
        public PRODUCT addProduct(int businessID, string name, string description, string category, string allergies, decimal price)
        {
            var product = new PRODUCT
            {
                BUSINESS_ID = businessID,
                NAME = name,
                DESCRIPTION = description,
                PRICE = price,
                ALLERGIES = allergies,
                CATEGORY = category,
                ISACTIVE = true
            };

            dataContext.PRODUCTs.InsertOnSubmit(product);

            try
            {
                dataContext.SubmitChanges();

                PRODUCT newProduct = new PRODUCT
                {
                    ID = product.ID,
                    NAME = product.NAME,
                    DESCRIPTION = product.DESCRIPTION,
                    PRICE = product.PRICE,
                    ALLERGIES = product.ALLERGIES,
                    CATEGORY = product.CATEGORY,
                    ISACTIVE = product.ISACTIVE
                };
                return newProduct;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }
        }

        //Customize the products based on attributes
        public bool editProduct(int id, string name, decimal price, string description, string allergies, string category, bool active)
        {
            var pro = (from p in dataContext.PRODUCTs
                       where p.ID.Equals(id)
                       select p).FirstOrDefault();

            if (pro != null)
            {
                pro.NAME = name;
                pro.DESCRIPTION = description;
                pro.PRICE = price;
                pro.ALLERGIES = allergies;
                pro.CATEGORY = category;
                pro.ISACTIVE = active;
            }

            try
            {
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        //This method removes a prod from catalogue
        public bool removeProduct(int Id)
        {
            var prod = (from p in dataContext.PRODUCTs
                        where p.ID.Equals(Id)
                        select p).FirstOrDefault();

            if (prod != null)
            {
                prod.ISACTIVE = false;
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteProduct(int ID)
        {
            var prod = (from p in dataContext.PRODUCTs
                        where p.ID.Equals(ID)
                        select p).FirstOrDefault();

            if (prod != null)
            {
                dataContext.PRODUCTs.DeleteOnSubmit(prod);
                dataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PRODUCT> getAllProducts(int businessID)
        {
            dynamic pro = (from p in dataContext.PRODUCTs
                           where p.BUSINESS_ID.Equals(businessID)
                           select p).DefaultIfEmpty();

            var listofProducts = new List<PRODUCT>();
            if (pro != null)
            {
                foreach (PRODUCT p in pro)
                {
                    if (p != null)
                    {
                        var P = new PRODUCT
                        {
                            ID = p.ID,
                            NAME = p.NAME,
                            DESCRIPTION = p.DESCRIPTION,
                            CATEGORY = p.CATEGORY,
                            PRICE = p.PRICE
                        };
                        listofProducts.Add(P);
                    }
                    else
                    {
                        return null;
                    }
                }
                return listofProducts;
            }
            else
            {
                return null;
            }
        }

        //Get all products
        public List<PRODUCT> getAllActiveProducts(int businessID)
        {
            dynamic pro = (from p in dataContext.PRODUCTs
                           where p.BUSINESS_ID.Equals(businessID)
                                && p.ISACTIVE.Equals(true)
                           select p).DefaultIfEmpty();

            List<PRODUCT> listofProducts = new List<PRODUCT>();
            if (pro != null)
            {
                foreach (PRODUCT p in pro)
                {
                    if (p != null)
                    {
                        PRODUCT P = new PRODUCT
                        {
                            ID = p.ID,
                            NAME = p.NAME,
                            DESCRIPTION = p.DESCRIPTION,
                            CATEGORY = p.CATEGORY,
                            PRICE = p.PRICE
                        };
                        listofProducts.Add(P);
                    }
                }
                return listofProducts;
            }
            else
            {
                return null;
            }
        }

        public List<PRODUCT> getAllActiveProductsFiltered(int businessID, string filter)
        {
            dynamic pro = null;
            if (filter.Equals("A-Z"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.NAME ascending
                       select p).DefaultIfEmpty();
            }
            else if (filter.Equals("Z-A"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.NAME descending
                       select p).DefaultIfEmpty();
            }
            else if (filter.Equals("H-L"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.PRICE ascending
                       select p).DefaultIfEmpty();
            }
            else if (filter.Equals("L-H"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.PRICE descending
                       select p).DefaultIfEmpty();
            }
            else if (filter.Equals("C A-Z"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.CATEGORY ascending
                       select p).DefaultIfEmpty();
            }
            else if (filter.Equals("C Z-A"))
            {
                pro = (from p in dataContext.PRODUCTs
                       where p.ISACTIVE.Equals(true)
                       orderby p.CATEGORY descending
                       select p).DefaultIfEmpty();
            }
            else
            {
                return getAllActiveProducts(businessID);
            }

            if (pro != null)
            {
                List<PRODUCT> listofProducts = new List<PRODUCT>();
                foreach (PRODUCT p in pro)
                {
                    PRODUCT P = new PRODUCT
                    {
                        ID = p.ID,
                        NAME = p.NAME,
                        DESCRIPTION = p.DESCRIPTION,
                        CATEGORY = p.CATEGORY,
                        PRICE = p.PRICE
                    };
                    listofProducts.Add(P);
                }
                return listofProducts;
            }
            else
            {
                return null;
            }

        }

        public PRODUCT getProduct(int productId)
        {
            //retrieving product
            var prod = (from p in dataContext.PRODUCTs
                        where p.ID.Equals(productId)
                        select p).FirstOrDefault();

            if (prod != null)
            {
                PRODUCT product = new PRODUCT
                {
                    ID = prod.ID,
                    NAME = prod.NAME,
                    DESCRIPTION = prod.DESCRIPTION,
                    PRICE = prod.PRICE,
                    CATEGORY = prod.CATEGORY,
                    ALLERGIES = prod.ALLERGIES,
                    ISACTIVE = prod.ISACTIVE
                };
                return product;
            }
            else
            {
                return null;
            }
        }

        public decimal getProductPrice(int productId)
        {
            var prod = (from p in dataContext.PRODUCTs
                        where p.ID.Equals(productId)
                        select p.PRICE).FirstOrDefault();

            return prod;
        }

        public string getProductName(int productId)
        {
            var prod = (from p in dataContext.PRODUCTs
                        where p.ID.Equals(productId)
                        select p.NAME).FirstOrDefault();

            return prod;
        }

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         */
        //BUSINESS Methods
        //Add a business
        public BUSINESS addRest(int ownerID, string name, string address, string image, string description)
        {
            var newRest = new BUSINESS
            {
                OWNER_ID = ownerID,
                NAME = name,
                ADDRESS = address,
                IMAGE = image,
                DESCRIPTION = description,
                ISACTIVE = true
            };

            this.dataContext.BUSINESSes.InsertOnSubmit(newRest);

            try
            {
                this.dataContext.SubmitChanges();

                BUSINESS business = new BUSINESS
                {
                    ID = newRest.ID,
                    NAME = newRest.NAME,
                    ADDRESS = newRest.ADDRESS,
                    IMAGE = newRest.IMAGE,
                    DESCRIPTION = newRest.DESCRIPTION,
                };
                return business;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return null;
            }
        }

        public bool editBusiness(int id, string name, string address, string image, string description, bool status)
        {
            var bus = (from r in dataContext.BUSINESSes
                       where r.ID.Equals(id)
                       select r).FirstOrDefault();

            bus.NAME = name;
            bus.ADDRESS = address;
            bus.IMAGE = image;
            bus.DESCRIPTION = description;
            bus.ISACTIVE = status;

            try
            {
                this.dataContext.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public bool deleteRest(int id)
        {
            var bus = (from r in dataContext.BUSINESSes
                       where r.ID.Equals(id)
                       select r).FirstOrDefault();

            if (bus != null)
            {
                bus.ISACTIVE = false;
            
                    this.dataContext.SubmitChanges();
                    return true;
    
            }
            else
            {
                return false;
            }


        }

        public string getBusName(int businessID)
        {
            var busName = (from b in dataContext.BUSINESSes
                           where b.ID.Equals(businessID)
                           select b.NAME).FirstOrDefault();

            if (busName != null)
            {
                return busName;
            }
            else
            {
                return null;
            }
        }

        public List<BUSINESS> getAllRests()
        {
            dynamic rest = (from r in dataContext.BUSINESSes
                            where r.ISACTIVE.Equals(true)
                            select r).DefaultIfEmpty();

            if (rest != null)
            {
                List<BUSINESS> listofRestaurants = new List<BUSINESS>();
                foreach (BUSINESS business_ in rest)
                {
                    //changes made to the method to return the Image and address
                    BUSINESS business = new BUSINESS
                    {
                        ID = business_.ID,
                        NAME = business_.NAME,
                        DESCRIPTION = business_.DESCRIPTION,
                        ADDRESS = business_.ADDRESS,
                        IMAGE = business_.IMAGE

                    };
                    listofRestaurants.Add(business);
                }
                return listofRestaurants;
            }
            else
            {
                return null;
            }
        }

        public BUSINESS getRest(int id)
        {
            var rest = (from r in dataContext.BUSINESSes
                        where r.ID.Equals(id)
                        select r).FirstOrDefault();

            if (rest != null)
            {
                BUSINESS bus = new BUSINESS
                {
                    ID = rest.ID,
                    NAME = rest.NAME,
                    ADDRESS = rest.ADDRESS,
                    IMAGE = rest.IMAGE,
                    DESCRIPTION = rest.DESCRIPTION
                };
                return bus;
            }
            else
            {
                return null;
            }
        }

        public List<BUSINESS> getAllRestByOwner(int ownerID)
        {
            dynamic rest = (from r in dataContext.BUSINESSes
                            where r.OWNER_ID.Equals(ownerID) && r.ISACTIVE.Equals(true)
                            select r).DefaultIfEmpty();

            if (rest != null)
            {
                List<BUSINESS> listofRestaurants = new List<BUSINESS>();
                foreach (BUSINESS r in rest)
                {
                    if(r!= null)
                    {
                        BUSINESS business = new BUSINESS
                        {
                            ID = r.ID,
                            NAME = r.NAME,
                            IMAGE = r.IMAGE,
                            DESCRIPTION = r.DESCRIPTION
                        };
                        listofRestaurants.Add(business);

                    }
                    
                }
                return listofRestaurants;
            }
            else
            {
                return null;
            }
        }

        public string getBusAddress(int budID)
        {
            var rest = (from r in dataContext.BUSINESSes
                        where r.ID.Equals(budID)
                        select r.ADDRESS).FirstOrDefault();

            if (rest != null)
            {
                return rest;
            }
            else
            {
                return null;
            }
        }

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         */
        //CART Methods


        public CART createCart(int userId, int prodId)
        {
            var product = (from produtc_ in this.dataContext.PRODUCTs
                           where produtc_.ID.Equals(prodId)
                           select produtc_).FirstOrDefault();

            if (product != null)
            {
                CART c = new CART
                {
                    USER_ID = userId,
                    PROD_SUBTOTAL = 0,
                    SERVICES_SUBTOTAL = 10,
                    TAX = 0,
                    TOTAL = 10,
                    DISCOUNT = 0,
                    TOTAL_PAID = 10,
                    BUSINESS_ID = product.BUSINESS_ID
                };

                dataContext.CARTs.InsertOnSubmit(c);

                try
                {
                    dataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return null;
                }

                BRIDGE bridge = new BRIDGE
                {
                    CART_ID = c.ID,
                    PRODUCT_ID = prodId,
                    PRICE = product.PRICE,
                    QUANTITY = 1
                };

                dataContext.BRIDGEs.InsertOnSubmit(bridge);
                calcCartTotal(c.ID);

                try
                {
                    dataContext.SubmitChanges();

                    CART tempCart = new CART
                    {
                        ID = c.ID
                    };
                    return tempCart;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return null;
                }
            }
            return null;
        }

        public CART getCartByUser(int userId)
        {
            return null;
        }


        public CART getCartAtBus(int userId, int busId)
        {
            var cart = (from c in dataContext.CARTs
                        where c.USER_ID.Equals(userId) && c.BUSINESS_ID.Equals(busId)
                        select c).FirstOrDefault();

            if (cart != null)
            {
                CART temp = new CART
                {
                    ID = cart.ID,
                    BUSINESS_ID = cart.BUSINESS_ID,
                    DISCOUNT = cart.DISCOUNT,
                    PROD_SUBTOTAL = cart.PROD_SUBTOTAL,
                    SERVICES_SUBTOTAL = cart.SERVICES_SUBTOTAL,
                    TAX = cart.TAX,
                    TOTAL = cart.TOTAL,
                    TOTAL_PAID = cart.TOTAL_PAID,
                    USER_ID = cart.USER_ID
                };
                return temp;
            }
            else
            {
                return null;
            }
        }

        public CART getCart(int cartId)
        {
            var cart = (from c in dataContext.CARTs
                        where c.ID.Equals(cartId)
                        select c).FirstOrDefault();

            if (cart != null)
            {
                CART tempCart = new CART
                {
                    ID = cart.ID,
                    USER_ID = cart.USER_ID,
                    PROD_SUBTOTAL = cart.PROD_SUBTOTAL,
                    SERVICES_SUBTOTAL = cart.SERVICES_SUBTOTAL,
                    TAX = cart.TAX,
                    TOTAL = cart.TOTAL,
                    DISCOUNT = cart.DISCOUNT,
                    TOTAL_PAID = cart.TOTAL_PAID,
                    BUSINESS_ID = cart.BUSINESS_ID
                };
                return tempCart;
            }
            else
            {
                return null;
            }
        }

        public List<BRIDGE> getProdsInCart(int cartId)//Get a list of products in cart
        {
            dynamic cartList = (from cl in dataContext.BRIDGEs
                                where cl.CART_ID.Equals(cartId)
                                select cl).DefaultIfEmpty();

            List<BRIDGE> listOfCartItems = new List<BRIDGE>();
            if (cartList != null)
            {
                foreach (BRIDGE cl in cartList)
                {
                    if (cl != null)
                    {
                        BRIDGE CartList = new BRIDGE
                        {
                            CART_ID = cl.CART_ID,
                            PRODUCT_ID = cl.PRODUCT_ID,
                            QUANTITY = cl.QUANTITY,
                            PRICE = cl.PRICE
                        };
                        listOfCartItems.Add(CartList);
                    }
                }
                return listOfCartItems;
            }
            else
            {
                return null;
            }
        }

        public bool addToCart(int userId, int productId, int cartId, int quantity)
        {
            var cart = (from c in dataContext.CARTs
                        where c.ID.Equals(cartId)
                        select c).FirstOrDefault();

            var product = (from p in dataContext.PRODUCTs
                           where p.ID.Equals(productId)
                           select p).FirstOrDefault();

            var item = (from i in dataContext.BRIDGEs
                        where i.CART_ID.Equals(cartId) && i.PRODUCT_ID.Equals(productId)
                        select i).FirstOrDefault();

            //CASE: Item quatity can be increased or decreased, and also removed
            //if the item is already in our cart
            if ((cart != null) && (product != null) && (item != null))
            {
                item.QUANTITY = quantity;

                //if item is being removed
                if (quantity == 0)
                {
                    dataContext.BRIDGEs.DeleteOnSubmit(item);
                    List<BRIDGE> items = getProdsInCart(cartId);
                    if(items == null)
                    {
                        dataContext.CARTs.DeleteOnSubmit(cart);
                    }
                }
            }
            //if the item is not in the cart
            else if ((cart != null) && (product != null))
            {
                BRIDGE newItem = new BRIDGE
                {
                    CART_ID = cartId,
                    PRODUCT_ID = productId,
                    QUANTITY = quantity,
                    PRICE = product.PRICE
                };

                dataContext.BRIDGEs.InsertOnSubmit(newItem);

            }
            else if (quantity == 0)
            {
                dataContext.BRIDGEs.DeleteOnSubmit(item);

            }
            //if the cart does not exist
            else if (cart == null)
            {
                CART c = new CART
                {
                    USER_ID = userId,
                    PROD_SUBTOTAL = 0,
                    SERVICES_SUBTOTAL = 10,
                    TAX = 0,
                    TOTAL = 10,
                    DISCOUNT = 0,
                    TOTAL_PAID = 10,
                    BUSINESS_ID = product.BUSINESS_ID
                };

                BRIDGE newItem = new BRIDGE
                {
                    CART_ID = c.ID,
                    PRODUCT_ID = productId,
                    QUANTITY = quantity,
                    PRICE = product.PRICE
                };

                dataContext.CARTs.InsertOnSubmit(c);
                dataContext.BRIDGEs.InsertOnSubmit(newItem);

            }

            try
            {
                dataContext.SubmitChanges();
                calcCartTotal(cartId);
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public int getProdQuantity(int productId, int cartId)
        {
            var item = (from i in dataContext.BRIDGEs
                        where i.CART_ID.Equals(cartId) && i.PRODUCT_ID.Equals(productId)
                        select i.QUANTITY).FirstOrDefault();

            if (item != 0)
            {
                return item;
            }
            else
            {
                return 0;
            }
        }

        public void calcCartTotal(int cartId)
        {
            var cart = (from c in dataContext.CARTs
                        where c.ID.Equals(cartId)
                        select c).FirstOrDefault();

            dynamic items = (from b in dataContext.BRIDGEs
                             where b.CART_ID.Equals(cart.ID)
                             select b).DefaultIfEmpty();

            if ((cart != null) && (items != null))
            {
                decimal tax = Convert.ToDecimal(15);
                decimal incl = Convert.ToDecimal(115);
                decimal excl = Convert.ToDecimal(100);
                decimal total = Convert.ToDecimal(0);
                decimal discount = Convert.ToDecimal(0);

                foreach (BRIDGE item in items)
                {
                    if (item != null)
                    {
                        decimal itemdiscounted = item.PRICE * item.QUANTITY;
                        decimal itemtotal = getProductPrice(item.PRODUCT_ID) * item.QUANTITY;

                        total += itemtotal;
                        discount += itemtotal - itemdiscounted;
                    }

                }

                cart.PROD_SUBTOTAL = total;
                cart.DISCOUNT = discount;
                cart.TAX = Convert.ToDecimal(tax / excl) * cart.PROD_SUBTOTAL;
                cart.TOTAL = cart.PROD_SUBTOTAL + cart.SERVICES_SUBTOTAL;
                cart.TOTAL_PAID = cart.TOTAL - cart.DISCOUNT;

                try
                {
                    dataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                }
            }
        }

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         */
        //DISCOUNT Methods
        public bool setDiscountCode(string code, int prodId, decimal newPrice)
        {
            DISCOUNT discount = new DISCOUNT
            {
                CODE = code,
                PRODUCT_ID = prodId,
                NEW_PRICE = newPrice,
                IS_ACTIVE = true
            };

            dataContext.DISCOUNTs.InsertOnSubmit(discount);

            try
            {
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }

        }

        public List<DISCOUNT> getBusDiscounts(int busId)
        {
            dynamic prods = (from p in dataContext.PRODUCTs
                             where p.BUSINESS_ID.Equals(busId)
                             select p).DefaultIfEmpty();

            if (prods != null)
            {
                List<DISCOUNT> litsofDis = new List<DISCOUNT>();
                foreach (PRODUCT p in prods)
                {
                    dynamic dis = (from d in dataContext.DISCOUNTs
                                   where d.PRODUCT_ID.Equals(p.ID)
                                   select d).DefaultIfEmpty();

                    if (dis != null)
                    {
                        foreach (DISCOUNT d in dis)
                        {
                            if (d != null)
                            {
                                DISCOUNT toAdd = new DISCOUNT
                                {
                                    ID = d.ID,
                                    CODE = d.CODE,
                                    PRODUCT_ID = d.PRODUCT_ID,
                                    NEW_PRICE = d.NEW_PRICE,
                                    IS_ACTIVE = d.IS_ACTIVE
                                };
                                litsofDis.Add(toAdd);
                            }
                        }
                    }
                }
                return litsofDis;
            }
            else
            {
                return null;
            }
        }

        public bool editDiscount(int disId, string code, decimal price, bool active)
        {
            var dis = (from d in dataContext.DISCOUNTs
                       where d.ID.Equals(disId)
                       select d).FirstOrDefault();

            DISCOUNT discount = new DISCOUNT
            {
                ID = dis.ID,
                CODE = code,
                PRODUCT_ID = dis.PRODUCT_ID,
                NEW_PRICE = price,
                IS_ACTIVE = active
            };

            dataContext.DISCOUNTs.InsertOnSubmit(discount);

            try
            {
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        public int getCodeProdID(string code, int busId)
        {
            dynamic prods = (from p in dataContext.PRODUCTs
                             where p.BUSINESS_ID.Equals(busId)
                             select p).DefaultIfEmpty();

            if (prods != null)
            {
                foreach (PRODUCT p in prods)
                {
                    var dis = (from d in dataContext.DISCOUNTs
                               where d.PRODUCT_ID.Equals(p.ID) && d.IS_ACTIVE.Equals(true) && d.CODE.Equals(code)
                               select d.PRODUCT_ID).FirstOrDefault();

                    if (dis != 0)
                    {
                        return dis;
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public bool addDiscountToCart(int cartId, int prodId, string code)
        {
            var bridge = (from b in dataContext.BRIDGEs
                          where b.CART_ID.Equals(cartId) && b.PRODUCT_ID.Equals(prodId)
                          select b).FirstOrDefault();

            var disc = (from d in dataContext.DISCOUNTs
                        where d.CODE.Equals(code) && d.PRODUCT_ID.Equals(prodId) && d.IS_ACTIVE.Equals(true)
                        select d.NEW_PRICE).FirstOrDefault();

            if ((disc != 0) && (bridge != null))
            {
                bridge.PRICE = disc;
                try
                {
                    dataContext.SubmitChanges();
                    calcCartTotal(cartId);
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         */
        //CHECKOUT Methods
        public INVOICE checkout(int cartId, string paymentmethod)
        {
            var cart = (from c in dataContext.CARTs
                        where c.ID.Equals(cartId)
                        select c).FirstOrDefault();

            dynamic items = (from b in dataContext.BRIDGEs
                             where b.CART_ID.Equals(cart.ID)
                             select b).DefaultIfEmpty();

            INVOICE invoice = new INVOICE
            {
                BUSINESS_ID = cart.BUSINESS_ID,
                USER_ID = cart.USER_ID,
                PROD_SUBTOTAL = cart.PROD_SUBTOTAL,
                TAX = cart.TAX,
                SERVICES_SUBTOTAL = cart.SERVICES_SUBTOTAL,
                TOTAL = cart.TOTAL,
                DISCOUNT = cart.DISCOUNT,
                TOTAL_PAID = cart.TOTAL_PAID,
                DATE_TIME = DateTime.Now,
                PAYMENT_METHOD = paymentmethod
            };

            dataContext.INVOICEs.InsertOnSubmit(invoice);

            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }

            List<ORDERITEM> listOfItems = new List<ORDERITEM>();
            List<BRIDGE> listToDelete = new List<BRIDGE>();
            foreach (BRIDGE cl in items)
            {
                BRIDGE CartList = new BRIDGE
                {
                    CART_ID = cl.CART_ID,
                    PRODUCT_ID = cl.PRODUCT_ID,
                    QUANTITY = cl.QUANTITY,
                    PRICE = cl.PRICE
                };
                listToDelete.Add(cl);

                ORDERITEM orderItem = new ORDERITEM
                {
                    INVOICE_ID = invoice.ID,
                    PRODUCT_NAME = getProductName(CartList.PRODUCT_ID),
                    PRODUCT_QUANTITY = CartList.QUANTITY,
                    PRODUCT_PRICE = CartList.PRICE
                };
                listOfItems.Add(orderItem);
            }

            dataContext.BRIDGEs.DeleteAllOnSubmit(listToDelete);
            dataContext.CARTs.DeleteOnSubmit(cart);

            dataContext.ORDERITEMs.InsertAllOnSubmit(listOfItems);

            try
            {
                dataContext.SubmitChanges();

                INVOICE i = new INVOICE
                {
                    ID = invoice.ID,
                    BUSINESS_ID = invoice.BUSINESS_ID,
                    USER_ID = invoice.USER_ID,
                    PROD_SUBTOTAL = invoice.PROD_SUBTOTAL,
                    TAX = invoice.TAX,
                    SERVICES_SUBTOTAL = invoice.SERVICES_SUBTOTAL,
                    TOTAL = invoice.TOTAL,
                    DISCOUNT = invoice.DISCOUNT,
                    TOTAL_PAID = invoice.TOTAL_PAID,
                    DATE_TIME = invoice.DATE_TIME,
                    PAYMENT_METHOD = invoice.PAYMENT_METHOD
                };

                return i;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }
        }

        public void checkItems(int cartId, string paymentmethod)
        {
            var cart = (from c in dataContext.CARTs
                        where c.ID.Equals(cartId)
                        select c).FirstOrDefault();

            dynamic items = (from b in dataContext.BRIDGEs
                             where b.CART_ID.Equals(cart.ID)
                             select b).DefaultIfEmpty();

        }

        public INVOICE getInvoice(int invoiceId)
        {
            var inv = (from i in dataContext.INVOICEs
                       where i.ID.Equals(invoiceId)
                       select i).FirstOrDefault();

            INVOICE invoice = new INVOICE
            {
                ID = inv.ID,
                BUSINESS_ID = inv.BUSINESS_ID,
                USER_ID = inv.USER_ID,
                PROD_SUBTOTAL = inv.PROD_SUBTOTAL,
                TAX = inv.TAX,
                SERVICES_SUBTOTAL = inv.SERVICES_SUBTOTAL,
                TOTAL = inv.TOTAL,
                DISCOUNT = inv.DISCOUNT,
                TOTAL_PAID = inv.TOTAL_PAID,
                DATE_TIME = inv.DATE_TIME,
                PAYMENT_METHOD = inv.PAYMENT_METHOD
            };
            return invoice;
        }

        public List<ORDERITEM> getItems(int invoice)
        {
            dynamic items = (from i in dataContext.ORDERITEMs
                             where i.INVOICE_ID.Equals(invoice)
                             select i).DefaultIfEmpty();

            List<ORDERITEM> listOfItems = new List<ORDERITEM>();
            foreach (ORDERITEM cartlist in items)
            {
                ORDERITEM orderItem = new ORDERITEM
                {
                    INVOICE_ID = cartlist.ID,
                    PRODUCT_NAME = cartlist.PRODUCT_NAME,
                    PRODUCT_QUANTITY = cartlist.PRODUCT_QUANTITY,
                    PRODUCT_PRICE = cartlist.PRODUCT_PRICE
                };
                listOfItems.Add(orderItem);
            }
            return listOfItems;
        }

        public List<INVOICE> getUserInvoices(int userID)
        {
            dynamic invList = (from i in dataContext.INVOICEs
                               where i.USER_ID.Equals(userID)
                               select i).DefaultIfEmpty();

            if (invList != null)
            {
                List<INVOICE> listInvoice = new List<INVOICE>();
                foreach (INVOICE inv in invList)
                {
                    INVOICE invoice = new INVOICE
                    {
                        ID = inv.ID,
                        BUSINESS_ID = inv.BUSINESS_ID,
                        USER_ID = inv.USER_ID,
                        PROD_SUBTOTAL = inv.PROD_SUBTOTAL,
                        TAX = inv.TAX,
                        SERVICES_SUBTOTAL = inv.SERVICES_SUBTOTAL,
                        TOTAL = inv.TOTAL,
                        DISCOUNT = inv.DISCOUNT,
                        TOTAL_PAID = inv.TOTAL_PAID,
                        DATE_TIME = inv.DATE_TIME,
                        PAYMENT_METHOD = inv.PAYMENT_METHOD
                    };
                    listInvoice.Add(invoice);
                }
                return listInvoice;
            }
            else
            {
                return null;
            }
        }

        public List<INVOICE> getBusInvoices(int busID)
        {
            dynamic invList = (from i in dataContext.INVOICEs
                               where i.BUSINESS_ID.Equals(busID)
                               select i).DefaultIfEmpty();

            if (invList != null)
            {
                List<INVOICE> listInvoice = new List<INVOICE>();
                foreach (INVOICE inv in invList)
                {
                    INVOICE invoice = new INVOICE
                    {
                        ID = inv.ID,
                        BUSINESS_ID = inv.BUSINESS_ID,
                        USER_ID = inv.USER_ID,
                        PROD_SUBTOTAL = inv.PROD_SUBTOTAL,
                        TAX = inv.TAX,
                        SERVICES_SUBTOTAL = inv.SERVICES_SUBTOTAL,
                        TOTAL = inv.TOTAL,
                        DISCOUNT = inv.DISCOUNT,
                        TOTAL_PAID = inv.TOTAL_PAID,
                        DATE_TIME = inv.DATE_TIME,
                        PAYMENT_METHOD = inv.PAYMENT_METHOD
                    };
                    listInvoice.Add(invoice);
                }
                return listInvoice;
            }
            else
            {
                return null;
            }
        }

        /*
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         **********************************************************************************************************************************************
         */
        //USER Methods
        public USER registerUser(string name, string secondaryName, string email, string password, string phoneNumber, string dob, string gender, string typeOf)
        {
            USER user = new USER
            {
                FISRT_NAME = name,
                LAST_NAME = secondaryName,
                EMAIL = email,
                PASSWORD = password,
                CELL_NUMBER = phoneNumber,
                DATE_OF_BIRTH = Convert.ToDateTime(dob).Date,
                GENDER = gender,
                TYPE_OF = typeOf,
                REGISTER_DATE = DateTime.Now,
                ISACTIVE = true
            };

            try
            {
                //submit the changes to the databse
                this.dataContext.USERs.InsertOnSubmit(user);
                this.dataContext.SubmitChanges(); //register the changes into the database

                var u = login(email, password);

                USER tempUser = new USER
                {
                    ID = u.ID,
                    EMAIL = u.EMAIL,
                    FISRT_NAME = u.FISRT_NAME,
                    LAST_NAME = u.LAST_NAME,
                    TYPE_OF = u.TYPE_OF
                };
                return tempUser;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }
        }

        //Edits a customer's information
        public bool editUser(int id, string name, string secondaryName, string email, string phoneNumber, string dob, string gender)
        {
            var user = this.dataContext.USERs.FirstOrDefault(u => u.ID.Equals(id));

            if (user != null)
            {
                user.FISRT_NAME = name;
                user.LAST_NAME = secondaryName;
                user.EMAIL = email;
                user.CELL_NUMBER = phoneNumber;
                user.DATE_OF_BIRTH = Convert.ToDateTime(dob).Date;
                user.GENDER = gender;

                this.dataContext.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool emailExists(string email)
        {
            return this.dataContext.USERs.Any(u => u.EMAIL.Equals(email));
        }

        public USER getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public USER getUserByID(int id)
        {
            var user = (from u in dataContext.USERs where u.ID.Equals(id) select u).FirstOrDefault();

            //check if the user is not equal to nothing
            if (user != null)
            {
                USER tempUser = new USER
                {
                    ID = user.ID,
                    EMAIL = user.EMAIL,
                    FISRT_NAME = user.FISRT_NAME,
                    LAST_NAME = user.LAST_NAME,
                    TYPE_OF = user.TYPE_OF
                };
                return tempUser;
            }
            else
            {
                return null;
            }

        }

        public USER login(string email, string password)
        {
            //getting a user who is a customer from the table (this is a base class)
            var user = (from user_ in this.dataContext.USERs
                        where (user_.PASSWORD.Equals(password)) && (user_.EMAIL.Equals(email))
                        select user_).FirstOrDefault();

            //check if the user is not equal to nothing
            if (user != null)
            {
                USER tempUser = new USER
                {
                    ID = user.ID,
                    EMAIL = user.EMAIL,
                    FISRT_NAME = user.FISRT_NAME,
                    LAST_NAME = user.LAST_NAME,
                    TYPE_OF = user.TYPE_OF,
                    CELL_NUMBER = user.CELL_NUMBER
                };
                return tempUser;
            }
            else
            {
                return null;
            }
        }

        public string logOut(string email, string password)
        {
            throw new NotImplementedException();
        }

        //Remove user as Admin (makes them a customer)
        public void removeAsAdmin(int id)
        {
            var user = (from u in dataContext.USERs
                        where u.ID.Equals(id)
                        select u).FirstOrDefault();

            user.TYPE_OF = "CUSTOMER";

            dataContext.USERs.InsertOnSubmit(user);

            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }


        
        public bool passwordChanged(string password, string email)
        {
            var user = this.dataContext.USERs.FirstOrDefault(user_ => user_.EMAIL.Equals(email));

            if (user != null)
            {
                user.PASSWORD = password;
                try
                {
                    this.dataContext.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return false;
                }
            }
            return false;
        }



        public List<PRODUCT> getSearchedProducts(string search, int businessID)
        {

            dynamic products = (from products_ in this.dataContext.PRODUCTs
                                where products_.NAME.Contains(search) && products_.ISACTIVE.Equals(true) && products_.BUSINESS_ID.Equals(businessID)
                                select products_).DefaultIfEmpty();

            if (products != null)
            {
                List<PRODUCT> listProducts = new List<PRODUCT>();

                // Loop through the distinct businesses and add them to the list
                foreach (PRODUCT product in products)
                {
                    if (product != null)
                    {
                        PRODUCT tempProd = new PRODUCT
                        {
                            BUSINESS_ID = product.BUSINESS_ID,
                            CATEGORY = product.CATEGORY,
                            DESCRIPTION = product.DESCRIPTION,
                            ID = product.ID,
                            ALLERGIES = product.ALLERGIES,
                            NAME = product.NAME,
                            ISACTIVE = product.ISACTIVE,
                            PRICE = product.PRICE
                        };
                        listProducts.Add(tempProd);
                    }
                }
               
                return listProducts;
            }
            return null;
        }


        public List<BUSINESS> getSearchedBusinessLocation(string search)
        {
            dynamic restaraunt = (from resturants_ in this.dataContext.BUSINESSes
                                  where resturants_.ADDRESS.Contains(search)
                                  select resturants_).DefaultIfEmpty();

            if (restaraunt != null)
            {

                List<BUSINESS> listResturants = new List<BUSINESS>();
                foreach (BUSINESS business in restaraunt)
                {
                    BUSINESS tempBis = new BUSINESS
                    {
                        ADDRESS = business.ADDRESS,
                        DESCRIPTION = business.DESCRIPTION,
                        NAME = business.NAME,
                        IMAGE = business.IMAGE,
                        ID = business.ID,
                    };
                    listResturants.Add(tempBis);
                }

                return listResturants;
            }

            return null;
        }

        public bool editCustomer(int id, string name, string surname, string email, string phoneNumer)
        {
            var customer = this.dataContext.USERs.FirstOrDefault(customer_ => customer_.ID.Equals(id));

            if (customer != null)
            {
                customer.FISRT_NAME = name;
                customer.LAST_NAME = surname;
                customer.EMAIL = email;
                customer.CELL_NUMBER = phoneNumer;

                this.dataContext.SubmitChanges();
            }

            return false;
        }
    }
}
