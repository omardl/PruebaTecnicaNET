# Prueba técnica para desarrollador .NET
## Requisitos
Hay que programar una aplicación utilizando cualquier tecnología .Net que contenga una acción consistente en conectarse a un servicio web y obtener una lista de clientes. Dicha lista de clientes debe ser grabada en una base de datos local. La aplicación contendrá otra acción consistente en obtener la lista de clientes de la base de datos creada, pero aplicando un filtro, y mostrarla en pantalla.

El sistema permitirá repetir el proceso de descarga de información, pero si la base de
datos ya contiene información, mostrará un mensaje en donde preguntará si se desea
borrar el contenido de la Base de datos para poder repetir la descarga. Si el usuario elije
"Sí" se borrará la información descargada previamente y se repetirá el proceso.

### Pasos detallados:
1. Se creará una acción del usuario que lanzará la descarga de la información en dos
pasos:

    a. Habrá que hacer un login dentro del método del servicio web http://url:8082/Service/Token con el cual recuperar el token con el cual identificarse para luego continuar con el proceso. El formato del parámetro "queryString" es: username=nombreUsuario&password=contraseña&grant_type=password

       Credenciales para el WS:
       usuario: pruebaNET
       contraseña: PruebaNET123
   
     b. Luego habrá que conectarse mediante el método del servicio web
http://url:8082/Service/api/customers
de donde recuperaremos los 100 primeros clientes. El servicio web de los
clientes tiene 3 parámetros que son obligatorios (orderby, top y skip).

2. A continuación, se guardarán los registros en una tabla en una BD de SQL Server
creada como se prefiera.

3. Se creará una acción que permitirá lanzar una ventana o listado de alguna forma
(página web, WinForms, etc) donde se listarán los datos de la tabla filtrando
solamente por los que el campo "TagSerie" comience por "602".

La base de datos local se puede crear manualmente con SQL Server Management Studio,
no es obligatorio crearla por programación, aunque se podría hacer.

## Documentación
### Selección del entorno y tecnologías
A al hora de decidir las tecnologías y lenguajes a utilizar para la prueba, se ha considerado el uso de
C# por ser el más acorde a la vacante, pudiendo mostrar el nivel de desempeño en un entorno más
familiar a la misma.

En cuanto a la interfaz de la aplicación, se ha optado por estudiar diversas opciones disponibles como
WinForms, WPF o ASP.NET; optando por utilizar WinForms dado que su sencillez se adecúa más a
la prueba realizada.

La prueba ha sido desarrollada utilizando la versión 8.0 del SDK de .NET y se ha generado el proyecto
utilizando la versión 22 de Visual Studio y el marco de trabajo para una aplicación de Windows Forms
en C#.

Para la base de datos, se ha utilizado la versión 16.0.100.6 de Microsoft SQL Server y la 20.2.1 de
SQL Server Management Studio. Además, se ha incluído en el proyecto la versión 6.0.2 del paquete
Microsoft.Data.SqlClient para la comunicación con la base de datos.

### Metodología y desarrollo
En primer lugar, se ha optado por comenzar, siguiendo la documentación de Microsoft y sus recomendaciones
en todo momento, con la creación de una aplicación de consola. Se ha utilizado Visual Studio
Code como IDE por la familiaridad con el mismo.

La aplicación de consola se desarrolló para realizar las primeras pruebas de comunicación con el servicio
y, posteriormente, con la base de datos local. Como apoyo para estudiar la estructura de las peticiones
y respuestas antes de desarrollar el código se utilizó Postman.

Una vez solventada la funcionalidad de comunicación con el servicio, se procedió a realizar la configuración de SQL Server y la creación de la base de datos local. Cabe mencionar que la comunicación en
local provocó una serie de errores que han requerido modificaciones en la configuración por defecto del
propio gestor y se desconoce si dichos errores persistirían en una comunicación remota con el gestor o
eran problemáticas exclusivas para realizar pruebas locales.

Con respecto a la base de datos, se ha optado por la creación manual de la misma, mientras que la
creación y modificación de la tabla se realiza directamente en la programación.

Una vez los datos se han obtenido y almacenado adecuadamente, se ha procedido a la creación de una
interfaz para poder llevar a cabo las acciones requeridas en los objetivos. En este caso, se ha creado
un proyecto de Windows Forms desde Visual Studio, habiendo desarrollado buena parte de la lógica
anteriormente en la aplicación de consola.

Se ha optado por una interfaz sencilla con un botón para cada acción y una serie de diálogos para
mostrar los avisos correspondientes a la finalización de la carga de los datos y la confirmación de la
sobrescritura de los mismos. Los datos obtenidos tras aplicar el filtrado se muestran en una tabla que,
por comodidad, se genera en una nueva ventana.

### Consideraciones finales
Hay ciertas cuestiones en el desarrollo de la prueba que sería posible mejorar, pero se han descartado
para no alargar en exceso el desarrollo de la misma. Quedan mencionadas a continuación:

- El token de acceso tiene un tiempo de vida que pudiera ser aprovechable modificando brevemente
el código, evitando realizar llamadas innecesarias al servicio.

- La base de datos podría ser creada directamente mediante el código para evitar la gestión manual
de la misma, pero se ha optado por la opción manual debido a la inversión de tiempo que causó
la configuración de SQL Server y la existencia de requisitos prioritarios en ese momento.

- La eliminación de los datos no requiere la eliminación de la propia tabla (lo cual ocurre en
este proyecto), que supone una operación innecesaria. Lo óptimo, ligado al punto anterior, sería
comprobar si existen la base de datos y la tabla únicamente al ejecutar la aplicación al inicio y
crearlos de ser necesario, sin necesidad de realizar nada más que borrados e inserciones las veces
que el usuario considere oportuno.

### Resultados:
<img width="904" height="462" alt="NET1" src="https://github.com/user-attachments/assets/80ebadb1-bb59-42e4-8e0b-f5396334a55d" />

<img width="905" height="461" alt="NET2" src="https://github.com/user-attachments/assets/1851790b-8dd6-4811-a6df-4f6628ae67a6" />

<img width="904" height="458" alt="NET3" src="https://github.com/user-attachments/assets/b1e7645a-ebfc-4771-bfb5-389b2cc02328" />

<img width="1259" height="361" alt="NET4" src="https://github.com/user-attachments/assets/3ff1877c-67db-4d24-93e2-3de476551a4a" />




