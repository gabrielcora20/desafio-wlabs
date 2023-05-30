db = db.getSiblingDB('wlabs');

db.createCollection('Usuario');

db.Usuario.insert({
	"email": "wlabs@gmail.com",
	"nome": "Wlabs",
	"senha": "CBA72QdD7H8YBcgefTqE2Q=="
});