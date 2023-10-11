using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AWForm
{
    class DataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;



        public List<Product> TotalProducts()

        {
            using (IDbConnection connection = new SqlConnection(connectionString))

            {
                List<Product> iL = new List<Product>();

                string sql = $@"SELECT Production.Product.ProductId, Production.Product.ProductModelID, Production.Product.Name, Production.Product.Color, Production.Product.Size, Production.ProductModel.Name, Production.Product.ListPrice, Production.ProductDescription.Description  
                                FROM 
                                    Production.Product 
                                    INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID
                                    INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID
                                    INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID
                                WHERE ProductModelProductDescriptionCulture.CultureID = 'En'";
                iL = connection.Query<Product>(sql).ToList();

                return iL;

            }
        }
        public List<ProductModel> GetAllProductsModel(string lang, int subCategory, string product)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> iL = new List<ProductModel>();

                string sql = "SELECT DISTINCT " +
                    "Production.ProductModel.ProductModelID, " +
                    $"Production.ProductModel.Name AS ProductModelName, Production.ProductDescription.Description, " +
                    $"Production.Product.Name,Production.Product.ListPrice " +
                    "FROM " +
                    "Production.Product " +
                    "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
                    "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
                    "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
                    "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
                    "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
                    $"WHERE ProductModelProductDescriptionCulture.CultureID = '{lang}' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.Name LIKE '%{product}%' ORDER BY ProductModelName";

                iL = connection.Query<ProductModel>(sql).ToList();

                //Intentar eliminar duplicados
                List<ProductModel> result = new List<ProductModel>();


                foreach (var iLs in iL)
                {
                    Boolean hola = false;
                    foreach (var punt in result)
                    {

                        if (punt.ProductModelName == iLs.ProductModelName)
                        {
                            hola = true;
                        }
                    }

                    if (hola != true)
                    {
                        result.Add(iLs);
                    }
                }
                return result;
            }
        }


        public List<Category> GetCategories()
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Category> cL = new List<Category>();

                string sql = "SELECT DISTINCT ProductCategoryID, Name FROM Production.ProductCategory ";

                cL = connection.Query<Category>(sql).ToList();

                return cL;
            }
        }

        public List<Subcategory> GetSubcategories(int id)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Subcategory> sbL = new List<Subcategory>();
                string sql = $"SELECT DISTINCT ProductsubcategoryID, Name FROM Production.ProductSubcategory WHERE ProductCategoryID = {id}";

                sbL = connection.Query<Subcategory>(sql).ToList();
                return sbL;
            }

        }

        public List<ProductModel> ShowProductModel(string lang, int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<ProductModel> sPM = new List<ProductModel>();

                string sql = "SELECT DISTINCT " +
                    "Production.ProductModel.ProductModelID, " +
                    $"Production.ProductModel.Name AS ProductModelName, Production.ProductDescription.Description, " +
                    $"Production.Product.Name,Production.Product.ListPrice " +
                    "FROM " +
                    "Production.Product " +
                    "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
                    "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
                    "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
                    "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
                    "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
                    $"WHERE ProductModelProductDescriptionCulture.CultureID = '{lang}' AND Product.ProductModelID IS NOT NULL AND Production.ProductModel.ProductModelID = {id} ORDER BY ProductModelName";

                sPM = connection.Query<ProductModel>(sql).ToList();

                List<ProductModel> result = new List<ProductModel>();

                foreach (var iLs in sPM)
                {
                    Boolean hola = false;
                    foreach (var punt in result)
                    {

                        if (punt.ProductModelName == iLs.ProductModelName)
                        {
                            hola = true;
                        }
                    }

                    if (hola != true)
                    {
                        result.Add(iLs);
                    }
                }
                return result;
            }

        }

        public List<Product> getColors(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> sPC = new List<Product>();

                string sql = "SELECT DISTINCT " +
                    "Production.ProductModel.ProductModelID, " +
                    $"Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, " +
                    $"Production.Product.Name,Production.Product.ListPrice, Production.Product.Color, Production.ProductModel.Name AS ModelName, Production.Product.Size " +
                    "FROM " +
                    "Production.Product " +
                    "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
                    "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
                    "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
                    "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
                    "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
                    $"WHERE Product.ProductModelID IS NOT NULL AND Product.ProductModelID ={id} ORDER BY ProductModel";

                sPC = connection.Query<Product>(sql).ToList();

                return sPC;
            }

        }

        public Product getPrice(int id, string color, string size)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                Product sP = new Product();

                string sql = "SELECT DISTINCT " +
               "Production.Product.ListPrice, Production.Product.ProductID " +
               "FROM " +
               "Production.Product " +
               "INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID " +
               "INNER JOIN Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID " +
               "INNER JOIN Production.ProductModel ON Production.Product.ProductModelID = Production.ProductModel.ProductModelID " +
               "INNER JOIN Production.ProductModelProductDescriptionCulture ON Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID " +
               "INNER JOIN Production.ProductDescription ON Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID " +
               $"WHERE Product.ProductModelID IS NOT NULL AND Product.ProductModelID = {id} AND Production.Product.Size = '{size}'AND Production.Product.Color = '{color}'";

                sP = connection.Query<Product>(sql).FirstOrDefault();

                return sP;

            }
        }

        public Product getPhoto(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                Product sP = new Product();
                string sql =
                    $@"SELECT Product.ProductID, Name, ProductPhoto.ProductPhotoID, ThumbNailPhoto, ThumbNailPhoto, LargePhoto, LargePhotoFileName
                    FROM Production.Product
                    INNER JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID
                    INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID
                    WHERE Product.ProductID = {id}";

                sP = connection.Query<Product>(sql).FirstOrDefault();
                return sP;
            }

        }

        public List<int> totalValueProducts()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<int> sP = new List<int>();
                string sql =
                    $@"SELECT DISTINCT (Production.Product.ProductModelID) 
                    FROM Production.Product WHERE ProductModelID IS NOT NULL ";

                sP = connection.Query<int>(sql).ToList();
                
                return sP;
            }

            

            
        }


    }
}
