import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BookHomeComponent} from "./pages/book-home/book-home.component";
import {BookDetailComponent} from "./pages/book-detail/book-detail.component";
import {BookEditComponent} from "./pages/book-edit/book-edit.component";
import {BookAddComponent} from "./pages/book-add/book-add.component";


const routes: Routes = [
  {path: 'books/add', component: BookAddComponent},
  {path: 'books/edit/:guid', component: BookEditComponent},
  {path: 'books/:guid', component: BookDetailComponent},
  {path: 'books', component: BookHomeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class BooksRoutingModule {
}
