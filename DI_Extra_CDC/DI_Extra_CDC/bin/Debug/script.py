import xml.etree.ElementTree as ET
import matplotlib.pyplot as plt
#Cojo el archivo
tree = ET.parse('datos.xml')
#Cojo el root del archivo
root = tree.getroot()
#Creo dos arrays vacíos: uno guardará las fechas, el otro guardará los datos, creando una tupla
fechas = []
datos = []
#Cojo el tipo de dato para ponerlo como nombre del plot
nombre = root[0].tag
#Iteramos sobre root
for child in root:
	#Aquí relleno los arrays con datos
	fecha = child[0].text
	#Para el de fecha cojo el primer hijo y luego lo spliteo para coger únicamente la fecha
	trozos = fecha.split('T')
	#Añado la fecha
	fechas.append(trozos[0])
	#Añado el dato
	datos.append(int(child[1].text))
fechas.reverse()
datos.reverse()
plt.plot(fechas, datos)
plt.ylabel(nombre)
plt.xticks(rotation = 90)
lim1 = datos[0]
lim2 = datos[len(datos) - 1]
plt.ylim([lim1, lim2 + (lim2 * 0.05)])
plt.grid()
plt.savefig('datos.png')
plt.show()