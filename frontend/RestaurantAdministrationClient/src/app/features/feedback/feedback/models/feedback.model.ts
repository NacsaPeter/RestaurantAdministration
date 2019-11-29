import { StarRatingComponent } from 'ng-starrating';

export interface ICreateFeedbackViewModel {
    serviceQuality: number;
    cleanness: number;
    foodQuality: number;
    atmosphere: number;
    other: string;
}

export interface IRatingViewModel {
    oldValue: number;
    newValue: number;
    starRating: StarRatingComponent;
}
