import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '../components/HomeView.vue'
import DoctorsView from '../components/DoctorsView.vue'
import AddDoctor from '../components/AddDoctor.vue'
import BusyDoctorsView from '../components/BusyDoctorsView.vue'

const routes = [
  { 
    path: '/', 
    name: 'home', 
    component: HomeView 
  },
  { 
    path: '/doctors', 
    name: 'doctors', 
    component: DoctorsView 
  },
  { 
    path: '/add-doctor', 
    name: 'add-doctor', 
    component: AddDoctor 
  },
  {
    path: '/busy-doctors', 
    name: 'busy-doctors',
     component: BusyDoctorsView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router