import {BookByAuthor} from "./book-by-author";

export interface AuthorWithBooks {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  description: string;
  books: BookByAuthor[];
  modified: string;
  created: string;
}
