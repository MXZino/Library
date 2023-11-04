import {Injectable} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {AuthorWithBooks} from "../../interfaces/author-with-books";
import {environment} from "../../../../../environments/environment";
import {PageResult} from "../../../shared/interfaces/page-result";
import {AddAuthor} from "../../interfaces/add-author";
import {EditAuthor} from "../../interfaces/edit-author";

@Injectable({
  providedIn: 'root'
})
export class AuthorsHttpService {

  constructor(private http: HttpClient) {
  }

  getAllAuthors(page: number, recordsPerPage: number, name: string | null): Observable<PageResult<AuthorWithBooks>> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('recordsPerPage', recordsPerPage.toString());

    if (name !== null) {
      params = params.set('name', name);
    }

    return this.http.get<PageResult<AuthorWithBooks>>(`${environment.apiUrl}/api/authors/all`, {params})
      .pipe(
        catchError(error => {
          console.log('Error while fetching authors:', error);
          return throwError(error);
        })
      );
  }

  getAuthor(authorId: string): Observable<AuthorWithBooks> {
    return this.http.get<AuthorWithBooks>(`${environment.apiUrl}/api/authors/${authorId}`)
      .pipe(
        catchError(error => {
          console.log('Error while fetching author:', error);
          return throwError(error);
        })
      );
  }

  removeAuthor(authorId: string): Observable<AuthorWithBooks> {
    return this.http.delete<AuthorWithBooks>(`${environment.apiUrl}/api/authors/${authorId}`)
      .pipe(
        catchError(error => {
          console.log('Error while deleting author:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }

  addAuthor(author: AddAuthor): Observable<any> {
    return this.http.post(`${environment.apiUrl}/api/authors`, author)
      .pipe(
        catchError(error => {
          console.log('Error while adding author:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }

  editAuthor(author: EditAuthor): Observable<any> {
    return this.http.put(`${environment.apiUrl}/api/authors`, author)
      .pipe(
        catchError(error => {
          console.log('Error while editing author:', error);
          alert(error.message);
          return throwError(error);
        })
      );
  }
}
