import {Component, Input} from '@angular/core';
import {BookWithAuthor} from "../../interfaces/book-with-author";

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent {
  @Input() books: BookWithAuthor[] | undefined;
  @Input() currentPage: number = 1;
  @Input() itemsPerPage: number = 20;
}
