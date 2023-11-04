import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookHomeComponent } from './pages/book-home/book-home.component';
import { BookEditComponent } from './pages/book-edit/book-edit.component';
import { BookDetailComponent } from './pages/book-detail/book-detail.component';
import {BooksRoutingModule} from "./books-routing.module";
import {SharedModule} from "../shared/shared.module";
import { BooksFilterComponent } from './components/books-filter/books-filter.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { BookAddComponent } from './pages/book-add/book-add.component';

@NgModule({
  declarations: [
    BookHomeComponent,
    BookEditComponent,
    BookDetailComponent,
    BooksFilterComponent,
    BooksListComponent,
    BookAddComponent
  ],
  imports: [
    CommonModule,
    BooksRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class BooksModule { }
