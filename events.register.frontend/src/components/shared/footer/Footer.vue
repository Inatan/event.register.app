<template>

  <div>
      <footer>
            <p>&copy; Copyright {{ date }} InaDev.me</p>
        </footer>
  </div>
</template>

<script>
export default {
data() {
    return {
      date: new Date().getFullYear(),
    }
  },
}
</script>
<style scoped>
    footer{
        background: linear-gradient(45deg,rgba(0,32,96,1) 0,rgba(6,3,141,1) 43%,rgba(163,35,142,1) 100%);
        width: 100%;
        height: 50px;
        position: absolute;
        left: 0;
    }

    

    p{
        position: relative;
        top: 0px;
        font-size: 14px;
        color: white;
    }
</style>