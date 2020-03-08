import NewsServices from "../services/newsServices";
import * as HttpStatus from "http-status";

class NewsController {

    sendResponse = function (res, statusCode, data) {
        res.status(statusCode).json({ result: data });
    }

    get(req, res) {
        NewsServices.get()
            .then(news => this.sendResponse(res, HttpStatus.OK, news))
            .catch(error => console.error.bind(console, `Error ${error}`));
    }


    getById(req, res) {
        const _id = req.params.id;
        NewsServices.getById(_id)
            .then(news => this.sendResponse(res, HttpStatus.OK, news))
            .catch(error => console.error.bind(console, `Error ${error}`));
    }

    create(req, res) {
        let vm = req.body;
        NewsServices.create(vm)
            .then(news => this.sendResponse(res, HttpStatus.OK, "Noticia cadastrada com sucesso!"))
            .catch(error => console.error.bind(console, `Error ${error}`));
    }

    update(req, res) {
        const _id = req.params.id;
        let news = req.body;

        NewsServices.update(_id, news)
            .then(news => this.sendResponse(res, HttpStatus.OK, ` ${news.title} foi atualizado com sucesso!`))
            .catch(error => console.error.bind(console, `Error ${error}`));
    }

    delete(req, res) {
        const _id = req.params.id;
        NewsServices.delete(_id)
            .then(
                () => this.sendResponse(HttpStatus.OK),
                 `Noticia deletada com sucesso`)
            .catch(error => console.error.bind(console, `Error ${error}`));
     }

}

export default new NewsController();
