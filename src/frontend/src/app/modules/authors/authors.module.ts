import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthorsRoutingModule} from "./authors-routing.module";
import { AuthorHomeComponent } from './pages/author-home/author-home.component';
import { AuthorDetailComponent } from './pages/author-detail/author-detail.component';
import { AuthorsListComponent } from './components/authors-list/authors-list.component';


@NgModule({
  declarations: [
  
    AuthorHomeComponent,
       AuthorDetailComponent,
       AuthorsListComponent
  ],
  imports: [
    CommonModule,
    AuthorsRoutingModule
  ]
})
export class AuthorsModule {
}
