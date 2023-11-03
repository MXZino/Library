import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent {
  @Input() currentPage: number = 1;
  @Input() totalPageCount: number = 1;
  @Input() recordsPerPage: number = 20;
  @Input() totalRecords: number = 0;

  @Output() pageSelected = new EventEmitter<number>();
  @Output() recordsPerPageChanged = new EventEmitter<number>();

  readonly pageOptions = [10, 20, 50, 100];
  get paginationList() {
    let startPage = this.currentPage - 1 <= 0 ? 1 : this.currentPage - 1;
    let endPage = this.currentPage + 1 > this.totalPageCount ? this.totalPageCount : this.currentPage + 1;
    let pages = [];
    for (let i = startPage; i <= endPage; i++) {
      pages.push(i);
    }
    return pages;
  }

  goToPage(page: number) {
    this.currentPage = page;
    this.pageSelected.emit(this.currentPage);
  }

  onChange(records: any){
    let selectedValue = records.target.value;

    if(selectedValue < 10)
      selectedValue = 10;

    if(selectedValue > 100)
      selectedValue = 100;

    this.recordsPerPage = selectedValue;
    this.recordsPerPageChanged.emit(this.recordsPerPage);
  }
}
