import {Component, OnInit} from '@angular/core';
import {AuthorsHttpService} from "../../services/http/authors-http.service";
import {ActivatedRoute, Router} from "@angular/router";
import {LoaderService} from "../../../shared/services/loader.service";
import {AuthorWithBooks} from "../../interfaces/author-with-books";

@Component({
  selector: 'app-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {

  authorId!: string;
  author?: AuthorWithBooks;
  editAuthorPath!: string
  removeAuthorText: string = "Czy na pewno chcesz usunąć pozycję?";

  constructor(private http: AuthorsHttpService, private route: ActivatedRoute, private loaderService: LoaderService, private router: Router) {
  }

  ngOnInit(): void {
    this.authorId = this.route.snapshot.paramMap.get('guid')!;
    this.editAuthorPath  = `authors/edit/${this.authorId}`;
    this.getAuthor();
  }

  private getAuthor(): void {
    this.http.getAuthor(this.authorId).subscribe({
      next: (data) => {
        this.author = data;
        this.loaderService.isLoading.next(false);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się pobrać danych.');
      }
    });
  }

  removeAuthor() {
    this.http.removeAuthor(this.authorId).subscribe({
      next: () => {
        this.loaderService.isLoading.next(false);
        this.router.navigate(['authors']);
      },
      error: (err) => {
        console.error('Error:', err);
        this.loaderService.isLoading.next(false);
        this.loaderService.error.next('Nie udało się usunąć pozycji.');
      }
    });
  }
}
