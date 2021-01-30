export default class ParticipanteServices {

    constructor(resource) {

        this._resource = resource('v1/ParticipanteEvento');
    }

    cadastra(foto) {
        if(foto._id){
            return this._resource.update({id: foto._id},foto)
        }
        else{
            return this._resource.save(foto);
        }
    }

    lista() {

        return this._resource
            .query()
            .then(
                res => res.json(),
                err => {
                    console.log(err);
                    throw new Error('Não foi possível obter as fotos. Tenta mais tarde');
                }
            )
    }

}