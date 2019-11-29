import { Component } from '@angular/core';
import { IRatingViewModel, ICreateFeedbackViewModel } from '../models/feedback.model';
import { Router } from '@angular/router';
import { FeedbackService } from '../services/feedback.service';
import { catchError, tap } from 'rxjs/operators';
import { of } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
    templateUrl: './feedback.page.component.html'
})
export class FeedbackPageComponent {

    isSent: boolean;

    feedback: ICreateFeedbackViewModel = {
        serviceQuality: null,
        cleanness: null,
        foodQuality: null,
        atmosphere: null,
        other: null
    };

    constructor(
        private router: Router,
        private snackbar: MatSnackBar,
        private service: FeedbackService,
    ) {}

    rate(event: IRatingViewModel, attribute: string) {
        this.feedback[attribute] = event.newValue;
    }

    send() {
        this.isSent = true;
        this.service.createFeedback(this.feedback).pipe(
            catchError(() => of(this.snackbar.open('Could not add feedback.', 'Close')))
        ).subscribe();
    }

    back() {
        this.router.navigateByUrl('/statistics');
    }
}
