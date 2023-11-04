import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthorsRoutingModule} from "./authors-routing.module";
import {AuthorHomeComponent} from './pages/author-home/author-home.component';
import {AuthorDetailComponent} from './pages/author-detail/author-detail.component';
import {AuthorsListComponent} from './components/authors-list/authors-list.component';
import {AuthorsFilterComponent} from './components/authors-filter/authors-filter.component';
import {FormsModule} from "@angular/forms";
import { AuthorAddComponent } from './pages/author-add/author-add.component';
import { AuthorEditComponent } from './pages/author-edit/author-edit.component';
import {SharedModule} from "../shared/shared.module";


@NgModule({
  declarations: [
    AuthorHomeComponent,
    AuthorDetailComponent,
    AuthorsListComponent,
    AuthorsFilterComponent,
    AuthorAddComponent,
    AuthorEditComponent
  ],
  imports: [
    CommonModule,
    AuthorsRoutingModule,
    FormsModule,
    SharedModule,
  ]
})
export class AuthorsModule {
}
