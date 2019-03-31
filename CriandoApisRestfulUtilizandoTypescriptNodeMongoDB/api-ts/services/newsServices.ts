import NewsRepository from '../repository/newsRepository';

class NewsServices {
    get(){
        return NewsRepository.find({});
    }

    getById(_id){
        return NewsRepository.findById({_id});
    }
}

export default new NewsServices();