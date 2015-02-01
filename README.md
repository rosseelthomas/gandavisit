# gandavisit
Mobile application for visiting the city of Ghent

De REST API zal draaien op host api.gandavisit.trosseel.be

de verschillende requests:
* GET http://api.gandavisit.trosseel.be/v1/spots  => lijst van verschillende plaatsen (naam,coordinaten,adres, andere info? Dit kan gebruikt worden om een niet al te zware lijst van de verschillende spots te tonen)

* GET http://api.gandavisit.trosseel.be/v1/spots/[SPOT_ID] gedetailleerde informatie over een spot
* POST http://api.gandavisit.trosseel.be/v1/spots/[SPOT_ID]/  met als post-parameters "userid" en "rating", dit wordt gebruikt om een rating te geven  (implementatie misschien pas in een later stadium)

