db = db.getSiblingDB('wlabs');

db.createCollection('Usuario');

db.Usuario.insert({
    "nome": "Wlabs",
    "email": "wlabs@gmail.com",
    "senha": "1234"
});