import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {BooksFilter} from "../../models/books-filter";

@Component({
  selector: 'app-books-filter',
  templateUrl: './books-filter.component.html',
  styleUrls: ['./books-filter.component.css']
})
export class BooksFilterComponent implements OnInit{

  filterForm!: BooksFilter;

  @Input() filter!: BooksFilter;
  @Output() filterApplied = new EventEmitter<BooksFilter>();

  ngOnInit(): void {
    this.filterForm = this.filter;
  }

  applyFilter() {
    this.filter = this.filterForm;
    this.filterApplied.emit(this.filterForm!);
  }
}
