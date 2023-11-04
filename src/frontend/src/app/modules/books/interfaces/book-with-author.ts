import {AuthorByBook} from "./author-by-book";

export interface BookWithAuthor {
  id: string;
  modified: Date;
  created: Date;
  title: string;
  author: AuthorByBook;
  ibnr: string;
  year: number;
}
