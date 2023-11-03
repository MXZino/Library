import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthorsRoutingModule} from "./authors-routing.module";
import {AuthorHomeComponent} from './pages/author-home/author-home.component';
import {AuthorDetailComponent} from './pages/author-detail/author-detail.component';
import {AuthorsListComponent} from './components/authors-list/authors-list.component';
import {AuthorsFilterComponent} from './components/authors-filter/authors-filter.component';
import {LoaderModule} from "../loader/loader.module";
import {PaginatorModule} from "../paginator/paginator.module";
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    AuthorHomeComponent,
    AuthorDetailComponent,
    AuthorsListComponent,
    AuthorsFilterComponent
  ],
  imports: [
    CommonModule,
    AuthorsRoutingModule,
    LoaderModule,
    PaginatorModule,
    FormsModule,
  ]
})
export class AuthorsModule {
}
