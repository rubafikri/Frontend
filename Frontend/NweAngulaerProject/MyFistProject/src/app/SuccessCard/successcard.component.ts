import { Component } from '@angular/core';

@Component({
  selector: 'app-successcard',
  template: ` <div class="warn">
      <p><strong>No Stop!</strong> You can not do like that</p>
    </div>
    <div class="success">
      <p><strong>Keep going </strong> You are very good person</p>
    </div>`,
  styles: [
    `
      div {
        margin-bottom: 15px;
        padding: 4px 12px;
      }

      .warn {
        background-color: #ffdddd;
        border-left: 6px solid #f44336;
      }
      .success {
        background-color: #ddffdd;
        border-left: 6px solid #04aa6d;
      }

      p {
        font-size: 25px;
      }
    `,
  ],
})
export class SuccessCardComponent {}
