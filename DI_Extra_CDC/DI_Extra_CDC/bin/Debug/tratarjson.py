# coding=UTF-8
import json as j

#Creo un objeto de tipo file
file = open('datos.json')

#Abro el archivo json
datos = j.load(file)

#El json es un array gigante con distintas entradas
for entrada in datos:
	if entrada['demographic_category'] == 'US':
		print('El dia: ' + entrada['date'].split('T')[0] + ' habia ' + entrada['series_complete_yes'] + ' personas vacunadas en USA')
#Cada entrada (objeto json) se trata como un diccionario de python, por lo que acceder es sencillo
#Si la entrada original (datos) tuviese varios objetos dentro, se trataría igual
file.close()