import {Component, OnInit} from '@angular/core';

import {ActivatedRoute, Router} from "@angular/router";
import {LoaderService} from "../../../shared/services/loader.service";
import {BooksHttpService} from "../../services/books-http.service";
import {BookWithAuthor} from "../../interfaces/book-with-author";

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit{

  bookId!: string;
  book?: BookWithAuthor;
  editBookPath!: string
  removeBookText: string = "Czy na pewno chcesz usunąć pozycję?";

  constructor(private http: BooksHttpService, private route: ActivatedRoute, private loaderService: LoaderService, private router: Router) {
  }
  ngOnInit(): void {
    this.bookId = this.route.snapshot.paramMap.get('guid')!;
    this.editBookPath  = `books/edit/${this.bookId}`;
    this.getBook();
  }

  private getBook(): void {
    this.http.getBook(this.bookId).subscribe({
      next: (data) => {
        this.book = data;
        this.loaderService.isLoading.next(false);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się pobrać danych.');
      }
    });
  }

  removeBook() {
    this.http.removeBook(this.bookId).subscribe({
      next: () => {
        this.loaderService.isLoading.next(false);
        alert("Poprawnie usunięto pozycję")
        this.router.navigate(['books']);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się usunąć pozycji.');
      }
    });
  }

}
