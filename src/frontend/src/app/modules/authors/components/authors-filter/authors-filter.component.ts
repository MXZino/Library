import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-authors-filter',
  templateUrl: './authors-filter.component.html',
  styleUrls: ['./authors-filter.component.css']
})
export class AuthorsFilterComponent implements OnInit{

  filterName: string | null = null;

  @Input() name: string | null = null;
  @Output() filterApplied = new EventEmitter<string>();

  ngOnInit() {
    this.filterName = this.name;
  }

  applyFilter() {
    this.name = this.filterName;
    console.log(this.name);
    this.filterApplied.emit(this.filterName!);
  }
}
