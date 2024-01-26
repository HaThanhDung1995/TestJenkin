/* groovylint-disable-next-line CompileStatic */
def skipBuild = branch
echo skipBuild
pipeline {
    agent any
    stages {
        stage('for dev branch'){
            when {
                branch 'DEV'
            }
            steps {
                echo 'main branch'
            }
        }
        stage('for main branch'){
            when {
                branch 'main'
            }
            steps {
                echo 'main branch'
            }
        }
    }
}
