# coding=UTF-8
#Importo pymysql
#Debe instalarse primero con pip install pymysql O pip install mariadb
#(Les llamo a los dos igual para poder cambiar rapidamente)
#import pymysql as my
import mariadb as my
import xml.etree.ElementTree as ET

#Uso pymysql para conectarme: connect(direcci?n, usuario, contrase?a, base de datos, clase de cursor) (SOLO MYSQL)
#db = my.connect(host='localhost',
#                             user='root',
#                             password='',
#                             database='northwind',
#                             cursorclass=my.cursors.DictCursor)
#Para mariadb
db = my.connect(
        user="root",
        password="",
        host="localhost",
        port=3306,
        database="northwind"
    )
print('Conexion realizada')

#Preparo un objeto cursor
cursor = db.cursor()
print('Cursor obtenido')

####################################################
#Voy a crear un XML para guardar los datos, no es obligatorio
#Para esto, le creo un objeto root
root = ET.Element("datos")
####################################################

try:
	#Le doy la instruccion que quiero al cursor
	sql = "SELECT company, first_name, last_name, city FROM customers WHERE job_title = 'OWNER'"
	cursor.execute(sql)
	print("SQL Ejecutado")
	#Cojo todos los reultados con fetchall()
	#Si me interesa coger solo uno, uso fetchone()
	#Para saber las filas afectadas, uso rowcount()
	#fetchall() coge todos los resultados que quedan por coger
	resultados = cursor.fetchall()
	print("Obtenidos datos")
	#Recorro todas las filas de los resultados
	for row in resultados:
		cliente = ET.SubElement(root, "cliente")
		compania = ET.SubElement(cliente, "company")
		compania.text = row[0]
		nombre = ET.SubElement(cliente, "nombre")
		nombre.text = row[1]
		apellidos = ET.SubElement(cliente, "apellidos")
		apellidos.text = row[2]
		ciudad = ET.SubElement(cliente, "ciudad")
		ciudad.text = row[3]
	#Le digo que root es la raiz del arbol y escribo
	tree = ET.ElementTree(root)
	tree.write("northwind.xml")
except my.Error as e :
	print("Error: unable to fetch data")
	print(f"Error: {e}")
#Apuntes interesantes:
#Las filas son tambi?n diccionarios, por lo que se puede hacer row['company'] y funcionar?a igual
#Se puede imprimir directamente un resultado con resultado = cursor.fetchone() y luego print(resultado)
#El formato resultante ser?a {'campo' : 'valor', ...}
#Se puede quitar el auto-commit (al menos en mariadb) con conexion.autocommit = False
#Esto permite hacer commit() y rollback() para implementar transacciones correctamente
#Otra manera de hacer el execute ser?a:
#sql = "SELECT company, first_name, last_name, city FROM customers WHERE job_title = ?"
#cursor.execute(sql, ('OWNER'))
#De esta manera podemos usar parametros. Todos los parametros que usemos deben ir entre parentesis
#En el segundo argumento del metodo execute()
#Si hacemos ET.dump(root) podemos ver que tiene root dentro y su estructura 
#(podemos ver la del elemento que queramos)