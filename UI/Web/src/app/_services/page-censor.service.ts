import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';
import {PageCensor} from '../_models/readers/page-censor';

@Injectable({ providedIn: 'root' })
export class PageCensorService {
  private readonly httpClient = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;

  getForChapter(chapterId: number): Observable<PageCensor[]> {
    return this.httpClient.get<PageCensor[]>(this.baseUrl + `page-censor/chapter/${chapterId}`);
  }

  upsert(dto: PageCensor): Observable<PageCensor> {
    return this.httpClient.put<PageCensor>(this.baseUrl + 'page-censor', dto);
  }

  delete(chapterId: number, pageIndex: number): Observable<void> {
    return this.httpClient.delete<void>(this.baseUrl + `page-censor?chapterId=${chapterId}&pageIndex=${pageIndex}`);
  }
}
