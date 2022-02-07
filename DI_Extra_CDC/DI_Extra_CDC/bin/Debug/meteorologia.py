import xml.etree.ElementTree as ET
import mariadb as mb

db = mb.connect(
        user="root",
        password="",
        host="localhost",
        port=3306,
        database="meteorologia"
    )

cursor = db.cursor()

root = ET.Element("datos")

try:
    sql = "SELECT e.nombre, m.Fecha, m.Hora, m.ICAEstacion FROM mediciones m join estaciones e on m.id_estacion = e.id"
    cursor.execute(sql)
    resultados = cursor.fetchall()
    x = 1
    for row in resultados:
        print("Entrada: " + str(x))
        entrada = ET.SubElement(root, "entrada")
        nombre = ET.SubElement(entrada, "nombre")
        nombre.text = str(row[0])
        fecha = ET.SubElement(entrada, "fecha")
        fecha.text = str(row[1])
        hora = ET.SubElement(entrada, "hora")
        hora.text = str(row[2])
        estado = ET.SubElement(entrada, "estado")
        estado.text = str(row[3])
        x = x+1
    tree = ET.ElementTree(root)
    tree.write(str("meteorologia.xml"), encoding="utf-8")
except mb.Error as e:
    print(f"Error: {e}")

try:
    sql = "SELECT nombre FROM estaciones"
    cursor = db.cursor()
    cursor.execute(sql)
    fichero = open("estaciones.txt" , "w")
    resultados = cursor.fetchall()
    for row in resultados:
        fichero.write(row[0] + "\n")
except:
    print("ERROR AL ESCRIBIR EN EL FICHERO TXT")