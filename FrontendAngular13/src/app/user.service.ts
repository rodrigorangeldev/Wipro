import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  usersUrl = 'https://jsonplaceholder.typicode.com/users'
  postsUrl = 'https://jsonplaceholder.typicode.com/posts'

  constructor() { }

  getUsersInfo(){
    return fetch(this.usersUrl)
  }

  getPostsInfo(){
    return fetch(this.postsUrl)
  }

  getPostsByUserId(userId:number){
    return fetch(`${this.postsUrl}?userId=${userId}`)
  }
}
