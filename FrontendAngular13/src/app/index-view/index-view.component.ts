import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Chart } from 'chart.js';

interface iUsers {
  id: number,
  name: string
}

interface iPosts {
  userId: number
}

interface iUserPosts {
  total:number,
  name:string,
  userId: number
}

interface ipostsByUser{
  title: string
}

@Component({
  selector: 'app-index-view',
  templateUrl: './index-view.component.html',
  styleUrls: ['./index-view.component.css']
})

export class IndexViewComponent implements OnInit {

  users: iUsers[] = []
  posts: iPosts[] = []
  labels: string[] = []
  data: number[] = []
  userPosts: iUserPosts[] = []
  postsByUser: ipostsByUser[] = []

  constructor(private userService: UserService) { }

  ngOnInit(): void {

    this.initGraphic();

    this.userService.getUsersInfo()
      .then(response => response.json())
      .then((json: iUsers[]) => {
        json.map(u => {
          const {id, name} = u;
          this.users.push({id, name})
        })

        this.users.map(u => {
          this.labels.push(u.name)
        })

        this.userService.getPostsInfo()
          .then(response => response.json())
          .then((json: iPosts[]) => {
            json.map(x => {
              const { userId } = x; 
              this.posts.push({userId})
            })
            this.countPosts();
            this.initGraphic();
          })
      })

  }

  countPosts(){
    this.users.map(u => {
      let randomNumber = Math.floor(Math.random() * 10);
      let totalPosts = this.posts.filter(p => p.userId == u.id)
      let total = (totalPosts.length - randomNumber)
      this.data.push(total)
      const {name, id} = u
      let user = {total, name, userId:id}
      this.userPosts.push(user)
    })
  }

  getUserPosts(userId:number){
 
    this.userService.getPostsByUserId(userId)
      .then(response => response.json())
      .then((json)  => {
        this.postsByUser = []
          json.map((post:ipostsByUser) => {
            const { title } = post
            this.postsByUser.push({title})
          })
      })
  }

  initGraphic(){
    var myChart = new Chart("myChart", {
      type: 'bar',
      data: {
        labels: this.labels,
        datasets: [{
          label: '# of Posts per User',
          data:this.data,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        }
      }
    });

  }

  


}
