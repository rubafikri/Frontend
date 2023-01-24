import { Component, OnInit } from '@angular/core';
import { IBookSuggestion } from '../interfaces/IBookSuggestions';
import { SuggestBookService } from '../Services/SuggestBook.service';

@Component({
  selector: 'app-suggestipn-book',
  templateUrl: './suggestipn-book.component.html',
  styleUrls: ['./suggestipn-book.component.css'],
})
export class SuggestipnBookComponent implements OnInit {
  loadedBookSuggestion: IBookSuggestion[];
  constructor(private bookSuggestionService: SuggestBookService) {}
  isRead: boolean;

  ngOnInit(): void {
    this.getBookSuggestions();
  }
  getBookSuggestions() {
    this.bookSuggestionService.getBookSuggestions().subscribe({
      next: (data) => {
        this.loadedBookSuggestion = data;
        console.log(this.loadedBookSuggestion);
      },
    });
  }
  onUpdate(id: number) {
    return this.bookSuggestionService.onupdateReadStatus(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getBookSuggestions();
      },
    });
  }
}
