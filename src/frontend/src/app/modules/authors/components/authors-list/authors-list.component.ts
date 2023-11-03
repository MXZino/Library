import {Component, Input} from '@angular/core';
import {AuthorWithBooks} from "../../interfaces/author-with-books";

@Component({
  selector: 'app-authors-list',
  templateUrl: './authors-list.component.html',
  styleUrls: ['./authors-list.component.css']
})
export class AuthorsListComponent {
  @Input() authors: AuthorWithBooks[] | undefined;
  @Input() currentPage: number = 1;
  @Input() itemsPerPage: number = 20;
}
