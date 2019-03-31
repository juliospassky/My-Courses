import * as mongoose from 'mongoose';

const NewsSchema = new mongoose.Schema({
    hat: {type:String},
    title: {type:String},
    text: {type:String},    
    author: {type:String},
    img: {type:Date},
    publishDate: {type:String},
    link: {type:String},
    active: {type:String},
})

export default NewsSchema;