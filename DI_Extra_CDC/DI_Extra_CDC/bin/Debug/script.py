#Viene de la stdlib, instalado con python
import xml.etree.ElementTree as ET
#Se tiene que instalar primero con 
#python -m pip install -U pip
#python -m pip install -U matplotlib
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
#Invierto los datos ya que entran al revés
fechas.reverse()
datos.reverse()
#Creo el gráfico con las fechas y los datos (x,y)
plt.plot(fechas, datos)
#Le doy el label a la Y
plt.ylabel(nombre)
#Roto las fechas para que se vean mejor
plt.xticks(rotation = 90)
#Establezco el primer límite
lim1 = datos[0]
#El segundo límite
lim2 = datos[len(datos) - 1]
#Los meto en el gráfico, y hago el segundo un poco más grande
plt.ylim([lim1, lim2 + (lim2 * 0.005)])
#Le pongo una cuadrícula
plt.grid()
#Guardo como imagen
plt.savefig('datos.png')
#Muestro
plt.show()