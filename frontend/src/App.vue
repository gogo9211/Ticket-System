<template>
	<Login/>
</template>

<script>
import Login from './components/Login.vue'

export default {
	name: 'App',
	components: {
		Login
	}
}
</script>

<style>
body {
	background-color: rgb(25, 25, 25);
}

#app {
	font-family: Avenir, Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
}
</style>
