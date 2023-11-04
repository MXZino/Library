import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {PageResult} from "../../shared/interfaces/page-result";
import {environment} from "../../../../environments/environment";
import {BookWithAuthor} from "../interfaces/book-with-author";
import {BooksFilter} from "../models/books-filter";

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
}
