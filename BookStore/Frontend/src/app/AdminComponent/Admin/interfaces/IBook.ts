import { IAuthor } from './IAuthor';
import { IBookReview } from './IBookReview';
import { ICategory } from './ICategory';
import { IPublisher } from './IPublisher';

export interface IBook {
  book: any;
  name: string;
  id: number;
  price: number;
  discount: number;
  about: string;
  image: string;
  publisherId: number;
  authorId: number;
  categoryId: number;
  pageCount: number;
  publishYear: number;
  author: IAuthor;
  category: ICategory;
  publisher: IPublisher;
  rating: number;
  favId :number;
}
