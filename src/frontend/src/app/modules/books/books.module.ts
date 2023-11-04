import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookHomeComponent } from './pages/book-home/book-home.component';
import { BookEditComponent } from './pages/book-edit/book-edit.component';
import { BookDetailComponent } from './pages/book-detail/book-detail.component';
import {BooksRoutingModule} from "./books-routing.module";

@NgModule({
  declarations: [
    BookHomeComponent,
    BookEditComponent,
    BookDetailComponent
  ],
  imports: [
    CommonModule,
    BooksRoutingModule
  ]
})
export class BooksModule { }
