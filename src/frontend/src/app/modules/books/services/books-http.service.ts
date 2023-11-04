import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {PageResult} from "../../shared/interfaces/page-result";
import {environment} from "../../../../environments/environment";
import {BookWithAuthor} from "../interfaces/book-with-author";
import {BooksFilter} from "../models/books-filter";
import {AuthorWithBooks} from "../../authors/interfaces/author-with-books";
import {EditBook} from "../interfaces/edit-book";
import {AddAuthor} from "../../authors/interfaces/add-author";
import {AddBook} from "../interfaces/add-book";

@Injectable({
  providedIn: 'root'
})
export class BooksHttpService {

  constructor(private http: HttpClient) {
  }

  getAllBooks(page: number, recordsPerPage: number, booksFilter: BooksFilter): Observable<PageResult<BookWithAuthor>> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('recordsPerPage', recordsPerPage.toString());

    if (booksFilter.title !== null) {
      params = params.set('title', booksFilter.title);
    }

    if (booksFilter.authorName !== null) {
      params = params.set('authorName', booksFilter.authorName);
    }

    if (booksFilter.yearEqualGreaterThan !== null) {
      params = params.set('yearEqualGreaterThan', booksFilter.yearEqualGreaterThan);
    }


    return this.http.get<PageResult<BookWithAuthor>>(`${environment.apiUrl}/api/books/all`, {params})
      .pipe(
        catchError(error => {
          console.log('Error while fetching books:', error);
          return throwError(error);
        })
      );
  }

  getBook(bookId: string): Observable<BookWithAuthor> {
    return this.http.get<BookWithAuthor>(`${environment.apiUrl}/api/books/${bookId}`)
      .pipe(
        catchError(error => {
          console.log('Error while fetching book:', error);
          return throwError(error);
        })
      );
  }

  removeBook(bookId: string): Observable<any> {
    return this.http.delete<AuthorWithBooks>(`${environment.apiUrl}/api/books/${bookId}`)
      .pipe(
        catchError(error => {
          console.log('Error while deleting author:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }

  editBook(book: EditBook): Observable<any> {
    return this.http.put(`${environment.apiUrl}/api/books`, book)
      .pipe(
        catchError(error => {
          console.log('Error while editing book:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }

  addBook(book: AddBook): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/books`, book)
      .pipe(
        catchError(error => {
          console.log('Error while adding book:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }
}
