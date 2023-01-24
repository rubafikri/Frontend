import { IBook } from './IBook';

export interface ISale {
  appUserId: string;
  bookId: number;
  amount: number;
  totalPrice: number;
  book: IBook;
  isSold: number;
  id: number;
}
