import { defineStore } from 'pinia'

export const useCounterStore = defineStore('counter', {
    state: () => ({ counter: 0 }),
    getters: {
      doubleCounter: (state) => state.counter * 2,
    },
    actions: {
      increase() {
        this.counter++
      },
      decrease() {
        this.counter--
      },
    },
  })