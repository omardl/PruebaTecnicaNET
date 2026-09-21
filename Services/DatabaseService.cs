using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;


namespace PruebaTecnicaNET.Services
{
    public class DatabaseService
    {
        // Parámetros para la conexión con la base de datos local
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "tcp:DESKTOP-TC83091\\SQLEXPRESS",
            IntegratedSecurity = true,
            InitialCatalog = "PruebaNET",
            Encrypt = true,
            TrustServerCertificate = true
        };


        // Query SQL para la creación de la tabla
        static string createTableSql =
                @"IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Customers')
                BEGIN
                    DROP TABLE Customers;
                END
                CREATE TABLE Customers (
                    Id BIGINT PRIMARY KEY IDENTITY(1,1),
                    ExternalId BIGINT,
                    Code NVARCHAR(MAX),
                    Active BIT,
                    Name NVARCHAR(MAX),
                    VATReg NVARCHAR(MAX),
                    REGA NVARCHAR(MAX),
                    TagSerie NVARCHAR(MAX),
                    RelationCode NVARCHAR(MAX),
                    RelationRoute NVARCHAR(MAX),
                    Type_code NVARCHAR(MAX),
                    Type_description NVARCHAR(MAX)
                );
                ";


        // Query SQL para insertar a los clientes en la tabla 
        // Nota: El Id anterior se almacena como ExternalId y se mantiene un Id interno en la base local
        static string insertSql =
                @"INSERT INTO Customers (ExternalId, Code, Active, Name, VATReg, REGA, TagSerie, 
                       RelationCode, RelationRoute, Type_code, Type_description)
                VALUES (@ExternalId, @Code, @Active, @Name, @VATReg, 
                        @REGA, @TagSerie, @RelationCode, 
                        @RelationRoute, @Type_code, @Type_description);";


        // Query SQL para filtrar los clientes por el campo TagSerie
        static string filterDataSql =
                @"IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Customers')
                BEGIN
                    SELECT * FROM Customers WHERE TagSerie LIKE '602%'
                END";


        // Query SQL para comprobar si la tabla existe
        static string checkTableExistsSql =
            @"SELECT 1
            FROM INFORMATION_SCHEMA.TABLES
            WHERE TABLE_SCHEMA = 'dbo'
            AND TABLE_NAME = 'Customers'
            ";


        // Almacena todos los clientes del objeto Json recibido como argumento
        public static async Task StoreData(JsonElement customers)
        {

            string connectionString = builder.ConnectionString;

            await using SqlConnection connectionToDatabase = new SqlConnection(connectionString);

            await connectionToDatabase.OpenAsync();

            using (SqlCommand tableCreation = new SqlCommand(createTableSql, connectionToDatabase))
            {
                tableCreation.ExecuteNonQuery();
            }

            foreach (var customer in customers.EnumerateArray())
            {
                using var command = new SqlCommand(insertSql, connectionToDatabase);

                command.Parameters.AddWithValue("@ExternalId", customer.GetProperty("Id").GetInt64());
                command.Parameters.AddWithValue("@Code", customer.GetProperty("Code").GetString());
                command.Parameters.AddWithValue("@Active", customer.GetProperty("Active").GetBoolean());
                command.Parameters.AddWithValue("@Name", customer.GetProperty("Name").GetString());
                command.Parameters.AddWithValue("@VATReg", customer.GetProperty("VATReg").GetString());
                command.Parameters.AddWithValue("@REGA", customer.GetProperty("REGA").GetString());
                command.Parameters.AddWithValue("@TagSerie", customer.GetProperty("TagSerie").GetString());
                command.Parameters.AddWithValue("@RelationCode", customer.GetProperty("RelationCode").GetString());
                command.Parameters.AddWithValue("@RelationRoute", customer.GetProperty("RelationRoute").GetString());

                var type = customer.GetProperty("Type");
                command.Parameters.AddWithValue("@Type_code", type.GetProperty("Code").GetString());
                command.Parameters.AddWithValue("@Type_description", type.GetProperty("Description").GetString());

                await command.ExecuteNonQueryAsync();
            }
            await connectionToDatabase.CloseAsync();
        }


        // Devuelve un objeto DataTable con los datos filtrados (aquellos donde el campo TagSerie comienza por 602)
        public static async Task<DataTable> ShowData()
        {

            DataTable dataTable = new DataTable();

            string connectionString = builder.ConnectionString;

            await using SqlConnection connectionToDatabase = new SqlConnection(connectionString);

            await connectionToDatabase.OpenAsync();

            using (SqlCommand filterDataQuery = new SqlCommand(filterDataSql, connectionToDatabase))
            {
                using (SqlDataAdapter dataReader = new SqlDataAdapter(filterDataQuery))
                {
                    dataReader.Fill(dataTable);
                }
            }

            return dataTable;
        }


        // Devuelve un Boolean que indica si la tabla existe en la base de datos
        public static async Task<Boolean> CheckTableExists()
        {
            string connectionString = builder.ConnectionString;

            await using SqlConnection connectionToDatabase = new SqlConnection(connectionString);

            await connectionToDatabase.OpenAsync();

            using (SqlCommand checkDataQuery = new SqlCommand(checkTableExistsSql, connectionToDatabase))
            {

                var queryResult = await checkDataQuery.ExecuteScalarAsync();

                return queryResult != null;
            }
        }
    }
}
