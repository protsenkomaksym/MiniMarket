import { createWebHistory, createRouter } from "vue-router"
import Home from "@/views/home.vue"
import About from "@/views/about.vue"

const routes = [
    {
      path: "/",
      name: "Home",
      component: Home,
    },
    {
        path: "/About",
        name: "About",
        component: About,
      },
  ]
  
  const router = createRouter({
    history: createWebHistory(),
    routes
  })

export default router